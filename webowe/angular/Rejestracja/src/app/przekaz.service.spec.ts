import { TestBed } from '@angular/core/testing';

import { PrzekazService } from './przekaz.service';

describe('PrzekazService', () => {
  let service: PrzekazService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PrzekazService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
