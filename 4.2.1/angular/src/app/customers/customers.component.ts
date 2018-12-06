import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CustomerListDto, CustomerServiceProxy, CustomerDto } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { finalize } from 'rxjs/operators';
import { CreateOrEditCustomerComponent } from './create-or-edit-customer/create-or-edit-customer.component';

@Component({
    templateUrl: './customers.component.html',
    animations: [appModuleAnimation()]
})
export class CustomersComponent extends PagedListingComponentBase<CustomerDto> {
    protected delete(entity: CustomerDto): void {
        throw new Error("Method not implemented.");
    }

    @ViewChild('createOrEditCustomerModal') createOrEditCustomerModal: CreateOrEditCustomerComponent;

    active: boolean = false;
    customers: CustomerListDto[] = [];

    constructor(
        injector: Injector,
        private _customerService: CustomerServiceProxy
    ) {
        super(injector);
    }

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this._customerService.getCustomers()
            .pipe(finalize(() => {
                 finishedCallback()
            }))
            .subscribe((result: any) => {
                this.customers = result.items;
                this.showPaging(result, pageNumber);
            });
    }


    // Show Modals
    createOrEditCustomer(id?: number): void {
        this.createOrEditCustomerModal.show(id);
    }
}
