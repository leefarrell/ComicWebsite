import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Comic } from '../_models/comic';
import { ComicService } from '../_services/comic.service';
import { Paging, PageResults } from '../_models/paging';

@Component({
  selector: 'app-comic-list',
  templateUrl: './comic-list.component.html',
  styleUrls: ['./comic-list.component.css']
})
export class ComicListComponent implements OnInit {
  comics: Comic[];
  comic: Comic = JSON.parse(localStorage.getItem('comic'));
  comicParameters: any = {};
  comicMode = false;
  paging: Paging;
  pageNumber = 1;
  pageSize = 6;

  constructor(private comicservice: ComicService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadComicInit();
  }

  pageChanged(event: any): void {
    this.paging.currentPage = event.page;
    // console.log(this.paging.currentPage);
    this.loadComic();
  }
  loadComicInit() {
    this.comicservice.getComics(this.pageNumber, this.pageSize).subscribe((comics: PageResults<Comic[]>) => {
      this.comics = comics.results;
      this.paging = comics.paging;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadComic() {
    this.comicservice.getComics(this.paging.currentPage, this.paging.comicsPerPage).subscribe((comics: PageResults<Comic[]>) => {
      this.comics = comics.results;
      this.paging = comics.paging;
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
