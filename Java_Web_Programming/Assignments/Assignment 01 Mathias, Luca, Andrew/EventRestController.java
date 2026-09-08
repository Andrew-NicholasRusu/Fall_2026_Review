package com.example.community_events;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController

public class EventRestController extends Event {



    /** Endpoint 1 - Event Information */
    @GetMapping("/eventInfo")
    public String eventInfo() {
        return "Event: " + this.getName() +"<br>"+ //had to add these as line breaks since HTML ignores \n
                "Location: " + this.getLocation() +"<br>"+
                "Available Seats: " + this.getAvailableSeats();
    } // http://localhost:8080/eventInfo

    /** Endpoint 2 - Registration Status */
    @GetMapping("/status")
    public String status() {
        String registrationMessage;
        if (this.getAvailableSeats() <= 0) { // Checks if the seats are unavailable:
            registrationMessage = "FULL";
        } else {
            registrationMessage = "OPEN";
        }

        return "Event: " + this.getName() +"<br>"+
                "Location: " + this.getLocation() +"<br>"+
                "Registration Status: " + registrationMessage +"<br>"+
                "Available Seats: " + this.getAvailableSeats();
        // If no seats are available, the output should be "FULL"
    } // http://localhost:8080/status
}
