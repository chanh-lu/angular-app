import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-form-register',
  templateUrl: './register.component.html',
})
export class RegisterComponent implements OnInit {
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly registerService: RegisterService
  ) { }

  registerForm!: FormGroup;

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required]
    });
  }

  submitForm() {
    if (this.registerForm.invalid) {
      return;
    }
    this.registerService
      .submitForm(this.registerForm.value)
      .subscribe(x => {
        console.info('name submitted');
      });
  }

  validateControl(controlName: string) {
    if (this.registerForm.get(controlName)?.invalid) {
      return true;
    }
    return false;
  }

  hasError(controlName: string, errorName: string) {
    if (this.registerForm.get(controlName)?.hasError(errorName)) {
      return true;
    }
    return false;
  }
}
