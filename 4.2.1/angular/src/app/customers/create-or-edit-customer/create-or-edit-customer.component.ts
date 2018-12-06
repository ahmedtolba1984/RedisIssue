import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef, OnInit } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { CustomerServiceProxy, CustomerDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-or-edit-customer-modal',
  templateUrl: './create-or-edit-customer.component.html'
})
export class CreateOrEditCustomerComponent extends AppComponentBase implements OnInit {

    @ViewChild('createOrEditCustomerModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    customer: CustomerDto = null;

    constructor(
        injector: Injector,
        private _customerService: CustomerServiceProxy,
    ) {
        super(injector);
    }

    ngOnInit(): void {
        
    }

    show(id? : number): void {
        this.active = true;
        this.customer = new CustomerDto();
        if(id)
        {
            this._customerService.getCustomerForEdit(id).subscribe(result => {
                this.customer = result;
            });
        }
        this.modal.show();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save(): void {
        this.saving = true;
        this._customerService.createOrUpdateCustomer(this.customer)
            .pipe(finalize(() => { this.saving = false; }))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(null);
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
