import { JsonIssueTemplatePage } from './app.po';

describe('JsonIssue App', function() {
  let page: JsonIssueTemplatePage;

  beforeEach(() => {
    page = new JsonIssueTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
