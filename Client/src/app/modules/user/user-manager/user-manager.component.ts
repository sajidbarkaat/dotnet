import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';

@Component({
  selector: 'user-manager',
  templateUrl: './user-manager.component.html',
  styleUrls: ['./user-manager.component.css']
})
export class UserManagerComponent implements OnInit {
  userList!: any[];

  constructor(private userService: UserService){}  
  
  ngOnInit(): void {
    this.userService.getAll().subscribe({
      next: (response: any) => { 
        this.userList = response;
        console.log(this.userList);
      },
      error: (error) => { 
        console.log(error);
      }
    });
  }
}
