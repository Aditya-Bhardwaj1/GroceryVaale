import { Component } from '@angular/core';
import { NgForOf } from '@angular/common';

@Component({
  selector: 'app-cardbody',
  templateUrl: './cardbody.component.html',
  styleUrls: ['./cardbody.component.scss']
})
export class CardbodyComponent {
     data=[
      {
        name: 'Vegatables',
        Url: "../../assets/Images/Vegatable-icon.jpg"
      },
      {
        name: 'Coffee and Drinks',
        Url: "../../assets/Images/coffee-icon.jpg"
      },
      {
        name: 'Milk and Dairy',
        Url: "../../assets/Images/milk&dairy-icon.jpg"
      },
      {
        name: 'Meat',
        Url: "../../assets/Images/meat-icon.jpg"
      },
      {
        name: 'Fresh Fruits',
        Url: "../../assets/Images/fruits-icon.jpg"
      },
      {
        name: 'Cleaning Essentials',
        Url: "../../assets/Images/cleaning&essential.jpg"
      }
    ]

}
