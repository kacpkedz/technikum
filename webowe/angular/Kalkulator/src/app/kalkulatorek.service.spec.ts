import { TestBed } from '@angular/core/testing';

import { KalkulatorekService } from './kalkulatorek.service';

describe('KalkulatorekService', () => {
  let service: KalkulatorekService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KalkulatorekService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
