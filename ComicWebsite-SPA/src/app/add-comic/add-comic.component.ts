import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ComicService } from '../_services/comic.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-comic',
  templateUrl: './add-comic.component.html',
  styleUrls: ['./add-comic.component.css']
})
export class AddComicComponent implements OnInit {
  @Output() cancelAddComic = new EventEmitter();
  model: any = {};

  constructor(private comicService: ComicService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  addComic() {
    this.comicService.addComic(this.model).subscribe(() => {
      this.alertify.success('Comic successfully added');
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.router.navigate(['/Home']);
    });
  }

  cancel() {
    this.cancelAddComic.emit(false);
  }
}
