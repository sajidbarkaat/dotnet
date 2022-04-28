import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { UserRoutingModule } from './user.routing';
import { UserManagerComponent } from './user-manager/user-manager.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    UserManagerComponent
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
