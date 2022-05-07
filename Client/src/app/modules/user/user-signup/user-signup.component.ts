import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'user-signup',
  templateUrl: './user-signup.component.html',
  styleUrls: ['./user-signup.component.css']
})
export class UserSignupComponent implements OnInit{
  signupForm!: FormGroup;

  constructor(){}

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      'firstName': new FormControl('', [Validators.required]),
      'lastName': new FormControl('', [Validators.required]),
      'username': new FormControl('', [Validators.required]),
      'password': new FormControl('', [Validators.required]),      
    });
  }

  onSignupHandler(): void {
    if(!this.signupForm.valid) {
      return;
    }
    
    console.log(this.signupForm.value);
  }
}
