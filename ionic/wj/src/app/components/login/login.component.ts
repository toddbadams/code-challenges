import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';
import { ForgotPasswordComponent } from '../forgotpassword/forgotpassword.component';

@Component({
  selector: 'wj-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {

  constructor(public modalCtrl: ModalController) { }

  async dismiss() {
    await this.modalCtrl.dismiss();
  }

  async fogotPassword() {
    const modal = await this.modalCtrl.create({
      component: ForgotPasswordComponent,
      animated: true,
      mode: 'ios',
      backdropDismiss: false,
      cssClass: 'forgot-modal',
    })

    return await modal.present();
  }
}
