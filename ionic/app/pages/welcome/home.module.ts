import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';


import { HomePageRoutingModule } from './home-routing.module';
import { HomePage } from './home.page';
import { LoginComponent } from 'src/app/components/login/login.component';
import { SignupComponent } from 'src/app/components/signup/signup.component';
import { ForgotPasswordComponent } from '../../components/forgotpassword/forgotpassword.component';
import { VideoService } from 'src/app/services/video/video.service';
import { FullscreenPage } from 'src/app/components/fullscreen/fullscreen.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    HomePageRoutingModule
  ],
  declarations: [HomePage, LoginComponent, SignupComponent, ForgotPasswordComponent, FullscreenPage]
})
export class HomePageModule {}
