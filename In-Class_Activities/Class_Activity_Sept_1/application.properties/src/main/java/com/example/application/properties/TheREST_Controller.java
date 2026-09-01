package com.example.application.properties;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class TheREST_Controller {

    @Value("${robotics.team.name}")
    private String teamName;

    @Value("${robotics.advisor.name}")
    private String advisorName;

    @Value("${robotics.season}")
    private String season;

    @GetMapping("/teaminfo")
    public String getTeamInfo() {
        return "Team: " + teamName + ", Advisor: " + advisorName + ", Season: " + season;
    }

}
