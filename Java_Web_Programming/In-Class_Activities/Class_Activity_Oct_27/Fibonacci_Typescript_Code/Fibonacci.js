"use strict";
// Write a Typescript program that prints the first 100 terms of the Fibonacci sequence.
exports.__esModule = true;
exports.generateFibonacci = void 0;
function generateFibonacci(length) {
    if (length <= 0)
        return [];
    var series = [0, 1];
    for (var i = 2; i < length; i++) {
        series.push(series[i - 1] + series[i - 2]);
    }
    return series.slice(0, length);
}
exports.generateFibonacci = generateFibonacci;
// Getting the first 100 terms:
console.log("First 100 terms of the Fibonacci sequence:");
console.log(generateFibonacci(100));
