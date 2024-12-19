import { TestBed } from '@angular/core/testing';

import { KoloService } from './kolo.service';

describe('KoloService', () => {
  let service: KoloService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KoloService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
