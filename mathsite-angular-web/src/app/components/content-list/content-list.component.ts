import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-content-list',
  templateUrl: './content-list.component.html',
  styleUrls: ['./content-list.component.css']
})
export class ContentListComponent implements OnInit {

  constructor() { }
  contents: any[] = [
    {id:1, title: "Üstel Fonksiyonun Türevi", author: "Şeref Küpeli" },
    {id:2, title: "Türevin Tanımı", author: "Şeref Küpeli" },

  ]
  ngOnInit(): void {
  }

}
