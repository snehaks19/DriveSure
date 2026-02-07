import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  constructor(private http: HttpClient) { }

  private apiUrl = 'https://localhost:7254/api/usermaster';

  login(userId: string, password: string) {
    return this.http.get(
      `https://localhost:7254/api/usermaster?userId=${userId}&password=${password}`
    );
  }
}
