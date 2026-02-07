import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Codes {
  constructor(private http: HttpClient) { }
   getddl(type: string, parent?: string) {
  if (parent) {
    return this.http.get<any[]>(
      `https://localhost:7254/api/codesmaster/${type}/${parent}/list`
    );
  }

  return this.http.get<any[]>(
    `https://localhost:7254/api/codesmaster/${type}/list`
  );
}
}
