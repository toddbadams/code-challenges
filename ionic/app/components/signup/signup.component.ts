import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular'
@Component({
  selector: 'wj-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {
  constructor(public modalCtrl: ModalController) { }

  async dismiss() {
    return await this.modalCtrl.dismiss();
  }

  signup() {
    console.log('sign up');
  }
}
