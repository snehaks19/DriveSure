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



  getPolicy(id: number) {
    return this.http.get('https://localhost:7254/api/MotorPolicy/${id}');
  }

  getPolicies() {
    return this.http.get<any[]>(
      'https://localhost:7254/api/MotorPolicy/main-list'
    );
  }

}
