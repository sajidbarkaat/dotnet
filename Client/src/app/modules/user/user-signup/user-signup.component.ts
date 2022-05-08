import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-signup',
  templateUrl: './user-signup.component.html',
  styleUrls: ['./user-signup.component.css']
})
export class UserSignupComponent implements OnInit{
  signupForm!: FormGroup;
  @ViewChild('sBtnSignupForm') sBtnSignupForm!: ElementRef;

  constructor(private userService: UserService){}

  ngOnInit(): void {
    this.signupForm = new FormGroup({
      'fName': new FormControl('', [Validators.required]),
      'lName': new FormControl('', [Validators.required]),
      'username': new FormControl('', [Validators.required]),
      'password': new FormControl('', [Validators.required]),      
    });
  }

  async onSignupHandler(): Promise<void> {
    if(!this.signupForm.valid) {
      return;
    }
    
    this.sBtnSignupForm.nativeElement.disabled = true;

    await this.userService.register(this.signupForm.value);

    this.sBtnSignupForm.nativeElement.disabled = false;
  }
}
