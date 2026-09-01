package com.example.mycoolapp1.rest;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/fun")

public class FunRestController {
    @RequestMapping("/hello")
    public String hello() {
        return "Hello World!";
    }
    // http://localhost:8080/fun/hello
    @RequestMapping("/bye")
    public String bye() {
        return "Bye World!";
    }
    // http://localhost:8080/fun/bye
}
