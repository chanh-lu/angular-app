import { HttpClient } from '@angular/common/http';
import { IUserModel } from '../models/user.model';
import { BASE_URL, RegisterService } from './register.service';
import { TestBed } from '@angular/core/testing';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';

let httpClient: HttpClient;
let httpTestingController: HttpTestingController;
let registerService: RegisterService;

beforeEach(() => {
  TestBed.configureTestingModule({
    imports: [HttpClientTestingModule],
  });

  httpClient = TestBed.inject(HttpClient);
  httpTestingController = TestBed.inject(HttpTestingController);
  registerService = new RegisterService(httpClient);
});

describe('RegisterService', () => {
  it(`submitForm should POST to ${BASE_URL} once`, (done: DoneFn) => {
    const user: IUserModel = {
      firstName: 'fn',
      lastName: 'ln',
    };

    registerService.submitForm(user).subscribe();

    const req = httpTestingController.expectOne(BASE_URL);
    expect(req.request.method).toEqual('POST');
    httpTestingController.verify();
    done();
  });
});
