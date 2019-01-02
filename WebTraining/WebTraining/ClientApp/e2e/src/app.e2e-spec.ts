// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

import { AppPage } from './app.po';

describe('WebTraining App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display application title: WebTraining', () => {
    page.navigateTo();
    expect(page.getAppTitle()).toEqual('WebTraining');
  });
});
