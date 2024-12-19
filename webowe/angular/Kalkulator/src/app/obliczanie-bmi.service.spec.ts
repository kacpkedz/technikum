import { TestBed } from '@angular/core/testing';

import { ObliczanieBMIService } from './obliczanie-bmi.service';

describe('ObliczanieBMIService', () => {
  let service: ObliczanieBMIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ObliczanieBMIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
