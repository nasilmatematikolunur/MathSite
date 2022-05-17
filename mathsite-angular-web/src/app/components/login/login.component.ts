import { Component, OnInit } from '@angular/core';
import { BackgroundService } from 'src/app/services/background.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[BackgroundService]
})
export class LoginComponent implements OnInit {
  
  constructor(private bgService:BackgroundService) {}
  imagePath=""
  ngOnInit(): void {
    this.bgService.getBackground().subscribe(data=>{
      this.imagePath=data.hdurl
    })
    
  }
}
