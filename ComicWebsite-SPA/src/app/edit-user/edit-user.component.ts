import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../_services/auth.service';
import { NgForm } from '@angular/forms';
import { Photo } from '../_models/photo';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  user: User;
  photo: Photo;

  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute,
    private authService: AuthService) { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser() {
    this.userService.getUser(this.authService.decodedToken.nameid).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error(error);
    });
  }

  updateUser() {
    this.userService.updateUser(this.authService.decodedToken.nameid, this.user).subscribe(next => {
      this.alertify.success('Profile updated');
      this.editForm.reset(this.user);
    }, error => {
      this.alertify.error(error);
    });
  }
  /*
  updateUserPhoto() {
    this.userService.updateUserPhoto(this.authService.decodedToken.nameid, this.photo).subscribe(next => {
      this.user.photoUrl = this.photo.url;
      this.alertify.success('Profile updated');
      this.editForm.reset(this.photo);
    }, error => {
      this.alertify.error(error);
    });
  }
  */
}
