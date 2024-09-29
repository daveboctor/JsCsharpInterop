// https://stackoverflow.com/questions/79023879/how-to-pass-js-function-argument-to-inline-c-sharp-in-cshtml

document.querySelector("#get-serial-id").addEventListener("click", () => {
    formatToSerial(document.querySelector("#serial-id").value);
});

function formatToSerial(id) {

    // For demo purposes, add multiple IDs in the 'data' array
    const data = [id, 123, 456];

    const csrfToken = document.querySelector('input[name="__RequestVerificationToken"]').value;

    const url = "api/SerialFormat";

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': csrfToken
        },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(responseData => {
            if (!responseData.serializedList || !Array.isArray(responseData.serializedList)) {
                document.querySelector("#web-api-result").textContent = "Empty serialized list";
                return;
            }
            let kvpConcat = "";
            const numOfEntries= responseData.serializedList.length;
            responseData.serializedList.forEach((kvp, index) => {
                const sep = index === numOfEntries -1? "": ", ";
                kvpConcat += kvp.key + "/" + kvp.value + sep;
            });
            document.querySelector("#web-api-result").textContent = kvpConcat;
        })
        .catch(error => {
            console.error(error);
        });
}
