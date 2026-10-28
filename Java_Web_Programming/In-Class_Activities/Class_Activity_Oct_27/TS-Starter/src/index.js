"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function greet(user) {
    return `Hello, ${user.name}! You are logged in as ${user.role}.`;
}
const currentUser = {
    id: 1,
    name: "Alex",
    role: "developer"
};
console.log(greet(currentUser));
//# sourceMappingURL=index.js.map