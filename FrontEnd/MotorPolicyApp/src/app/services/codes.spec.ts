import { TestBed } from '@angular/core/testing';

import { Codes } from './codes';

describe('Codes', () => {
  let service: Codes;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Codes);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
