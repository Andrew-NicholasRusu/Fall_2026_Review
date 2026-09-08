package com.example.community_events;

import java.io.Serializable;

public class Event implements Serializable {

    private int id;
    private String name;
    private String location;
    private int availableSeats;


    public Event() {
        this.setId(808);
        this.setName("Raccoon Wedding");
        this.setLocation("THE Raccoon Church of Raccoons");
        this.setAvailableSeats(5);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public int getAvailableSeats() {
        return availableSeats;
    }

    public void setAvailableSeats(int availableSeats) {
        this.availableSeats = availableSeats;
    }

}
