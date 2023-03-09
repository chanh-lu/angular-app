import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RegisterService } from '../services/register.service';

@Component({
  selector: 'app-form-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly registerService: RegisterService
  ) {}

  registerForm!: FormGroup;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    });
  }

  submitForm(): void {
    if (this.registerForm.invalid) {
      return;
    }
    this.registerService.submitForm(this.registerForm.value).subscribe();
  }

  validateControl(controlName: string): boolean {
    if (this.registerForm.get(controlName)?.invalid) {
      return true;
    }
    return false;
  }
}
