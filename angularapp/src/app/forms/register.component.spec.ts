import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable } from 'rxjs';
import { IUserModel } from '../models/user.model';
import { RegisterService } from '../services/register.service';
import { RegisterComponent } from './register.component';

let component: RegisterComponent;
let fixture: ComponentFixture<RegisterComponent>;

const registerServiceStub: Partial<RegisterService> = {
  submitForm(_userModel): Observable<IUserModel> {
    return new Observable();
  },
};

beforeEach(() => {
  TestBed.configureTestingModule({
    declarations: [RegisterComponent],
    providers: [{ provide: RegisterService, useValue: registerServiceStub }],
  });
});

describe('RegisterComponent', () => {
  it('should have <form>', () => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    const form = fixture.nativeElement.querySelector('form');
    expect(form).not.toBeNull();
  });

  it('should have <label> and <input> for #first-name', () => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    const label = fixture.nativeElement.querySelector(
      'label[for="first-name"]'
    );
    const input = fixture.nativeElement.querySelector('#first-name');
    expect(label.textContent).toBe('First Name');
    expect(input).not.toBeNull();
  });

  it('should have <label> and <input> for #last-name', () => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    const label = fixture.nativeElement.querySelector('label[for="last-name"]');
    const input = fixture.nativeElement.querySelector('#last-name');
    expect(label.textContent).toBe('Last Name');
    expect(input).not.toBeNull();
  });
});
