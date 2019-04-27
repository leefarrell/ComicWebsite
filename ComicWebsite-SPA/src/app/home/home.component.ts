import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ComicService } from '../_services/comic.service';
import { AlertifyService } from '../_services/alertify.service';
import { Comic } from '../_models/comic';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  comics: Comic[];

  constructor(private http: HttpClient, private comicservice: ComicService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadComic();
  }
  loadComic() {
    this.comicservice.getComicsH().subscribe((comics: Comic[]) => {
      this.comics = comics;
    }, error => {
      this.alertify.error(error);
    });
  }

  registerToggle() {
    this.registerMode = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerMode = registerMode;
  }

}
