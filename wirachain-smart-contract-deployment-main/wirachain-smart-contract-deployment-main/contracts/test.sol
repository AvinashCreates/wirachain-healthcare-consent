// SPDX-License-Identifier: MIT 
pragma solidity ^0.8.26;

contract HelloWorld {
  string private message;
  constructor() {
    message = "Hello World";
  }
  
  /// @notice Returns a message
  function read() external view returns (string memory) {
    return message;
  }

  /// @notice Cambia el mensaje
  function write(string calldata newMessage) external {
    message = newMessage;
  }
}