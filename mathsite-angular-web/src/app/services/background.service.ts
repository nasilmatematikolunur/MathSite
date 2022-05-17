import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApodResponse } from '../models/apodResponse';
import {Observable } from 'rxjs';

@Injectable()
export class BackgroundService {
  path =
    'https://api.nasa.gov/planetary/apod?api_key=u5RZN49pOppd9JmVoi4GW1ranY6m4kwRThWslcxK';

  constructor(private http: HttpClient) {}

  getBackground() : Observable<ApodResponse> {
    return this.http.get<ApodResponse>(this.path)

  }
}
