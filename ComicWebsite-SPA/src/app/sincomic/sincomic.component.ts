import { Component, OnInit, Input } from '@angular/core';
import { Comic } from '../_models/comic';

@Component({
  selector: 'app-sincomic',
  templateUrl: './sincomic.component.html',
  styleUrls: ['./sincomic.component.css']
})
export class SincomicComponent implements OnInit {
@Input() comic: Comic;

  constructor() { }

  ngOnInit() {
  }

}
