import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'wj-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styleUrls: ['./forgotpassword.component.scss'],
})
export class ForgotPasswordComponent {

  constructor(public modalCtrl: ModalController) { }

  async dismiss() {
    await this.modalCtrl.dismiss();
  }
  recover() {
    console.log('recover password');
  }
}
