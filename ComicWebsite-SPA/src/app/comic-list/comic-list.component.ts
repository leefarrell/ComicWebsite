import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Comic } from '../_models/comic';
import { ComicService } from '../_services/comic.service';

@Component({
  selector: 'app-comic-list',
  templateUrl: './comic-list.component.html',
  styleUrls: ['./comic-list.component.css']
})
export class ComicListComponent implements OnInit {
  comics: Comic[];
  comicMode = false;

  constructor(private comicservice: ComicService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadComic();
  }
  loadComic() {
    this.comicservice.getComics().subscribe((comics: Comic[]) => {
      this.comics = comics;
    }, error => {
      this.alertify.error(error);
    });
  }
  comicToggle() {
    this.comicMode = true;
  }

  cancelComicMode(registerMode: boolean) {
    this.comicMode = registerMode;
  }

}
