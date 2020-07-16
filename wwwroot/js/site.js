// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function addSpeaker(event) {
    var speakerName = document.querySelector('#addSpeakerInput').value;
    var speakerTopic = "Faith";

    if (!speakerName || !speakerTopic) return;

    var speakerCount = document.querySelectorAll('.speaker-group').length;
    var speakerNumber = speakerCount + 1;
    var formGroup = document.createElement('div');
    formGroup.innerHTML = `
        <fieldset class="speaker-group">
            <legend>Speaker ${speakerNumber}</legend>
            <label for="speaker${speakerNumber}" class="control-label">Speaker ${speakerNumber}</label>
            <input id="speaker${speakerNumber}" name="Speaker" type="text" value=${speakerName} class="form-control" />

            <label for="speaker${speakerNumber}Topic" class="control-label">Speaker ${speakerNumber} Topic</label>
            <input id="speaker${speakerNumber}Topic" name="Topic" type="text" value=${speakerTopic} class="form-control" />

            <button type="button" class="btn btn-danger remove-speaker" onclick="removeSpeaker(event)">Remove Speaker</button>
        </fieldset>
    `;
    formGroup.classList.add('form-group');
    formGroup.classList.add('speaker');

    document.querySelector('#speakers').appendChild(formGroup);
    document.querySelector('#addSpeakerInput').value = '';

}

function removeSpeaker(e) {
    var parent = e.target.parentElement;
    parent.remove();
}