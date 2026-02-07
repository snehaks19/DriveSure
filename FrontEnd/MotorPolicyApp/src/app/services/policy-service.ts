import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PolicyService {
  constructor(private http: HttpClient) { }

  submitPolicy(data: any) {
    console.log(data);
    return this.http.post(
      'https://localhost:7254/api/MotorPolicy',
      data
    );
  }
}
