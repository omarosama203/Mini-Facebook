// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function editPost(postId, postBody) {
    // Create a form element
    var form = document.createElement('form');
    form.method = 'post';
    form.action = '/Home/EditPost'; // Change the action to the appropriate URL in your application

    // Create input fields for post ID and body
    var postIdInput = document.createElement('input');
    postIdInput.type = 'hidden';
    postIdInput.name = 'postId';
    postIdInput.value = postId;
    form.appendChild(postIdInput);

    var bodyLabel = document.createElement('label');
    bodyLabel.innerHTML = 'Post Body:';
    form.appendChild(bodyLabel);

    var bodyTextarea = document.createElement('textarea');
    bodyTextarea.name = 'postBody';
    bodyTextarea.value = postBody;
    form.appendChild(bodyTextarea);

    // Create a submit button
    var submitButton = document.createElement('button');
    submitButton.type = 'submit';
    submitButton.innerHTML = 'Save';
    form.appendChild(submitButton);

    // Append the form to the body
    document.body.appendChild(form);
}





