import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUserModel } from '../models/user.model';
import { Observable } from 'rxjs';

export const BASE_URL = '/api/Register';

export interface IRegisterService {
  submitForm(userModel: IUserModel): Observable<IUserModel>;
}

@Injectable({
  providedIn: 'root',
})
export class RegisterService implements IRegisterService {
  private readonly httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private readonly httpClient: HttpClient) {}

  submitForm(userModel: IUserModel): Observable<IUserModel> {
    return this.httpClient.post<IUserModel>(
      BASE_URL,
      userModel,
      this.httpOptions
    );
  }
}
