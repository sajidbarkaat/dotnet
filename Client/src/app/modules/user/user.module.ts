import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { UserRoutingModule } from './user.routing';

import { SharedModule } from '../shared/shared.module';

import { UserManagerComponent } from './user-manager/user-manager.component';
import { UserSignupComponent } from './user-signup/user-signup.component';
import { UserListComponent } from './user-list/user-list.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    UserManagerComponent,
    UserListComponent,
    UserSignupComponent
  ],
  imports: [        
    HttpClientModule,    
    UserRoutingModule,
    SharedModule
  ],
  providers: [
  ]
})
export class UserModule { }
