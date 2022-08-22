import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';

import { TastingsService } from './tastings.service';

describe('TastingsService', () => {
  let service: TastingsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TastingsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
