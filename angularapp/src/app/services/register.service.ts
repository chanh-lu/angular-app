import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { IUserModel } from "../models/user.model";

@Injectable({
  providedIn: 'root'
})

export class RegisterService {
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private readonly httpClient: HttpClient) { }

  submitForm(userModel: IUserModel) {
    return this.httpClient.post<IUserModel>('/api/Register', userModel, this.httpOptions);
  }
}
