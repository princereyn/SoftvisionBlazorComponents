// This is a JavaScript module that is loaded on demand. It can export any number of
// functions, and may import other JavaScript modules if required.

export function showPrompt(message) {
    return prompt(message, 'Type anything here');
}

export function enableNavButton(element, enable) {
    var childAnchor = element.querySelector('a');
    if (enable) {
        element.classList.remove('disabled');
        if (childAnchor != null)
            childAnchor.removeAttribute('tabindex');
    }
    else {
        element.classList.add('disabled');
        if (childAnchor != null)
            childAnchor.setAttribute('tabindex', '-1');
    }
}

export function setInputValue(element, value) {
    element.value = value;
}