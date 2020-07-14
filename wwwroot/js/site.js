// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function addSpeaker(event) {
    var speakerName = document.querySelector('#addSpeakerInput').value;
    var speakerCount = document.querySelectorAll('.speaker').length;
    var speakerNumber = speakerCount + 1;
    var formGroup = document.createElement('div');
    formGroup.innerHTML = `
        <label for="speaker${speakerNumber}" class="control-label">Speaker ${speakerNumber}</label>
        <input id="speaker${speakerNumber}" name="Speaker" type="text" value=${speakerName} class="form-control" />
    `;
    formGroup.classList.add('form-group');
    formGroup.classList.add('speaker');

    document.querySelector('#speakers').appendChild(formGroup);
    document.querySelector('#addSpeakerInput').value = '';

}