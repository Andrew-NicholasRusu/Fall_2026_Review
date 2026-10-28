// Write a Typescript program that prints the first 100 terms of the Fibonacci sequence.

export function generateFibonacci(length: number): number[] {
    if (length <= 0) return [];

    const series: number[] = [0, 1];

    for (let i = 2; i < length; i++) {
        series.push(series[i - 1] + series[i - 2]);
    }

    return series.slice(0, length);
}

// Getting the first 100 terms:
console.log("First 100 terms of the Fibonacci sequence:");
console.log(generateFibonacci(100));
