// Source:
// Call .NET methods from JavaScript functions in ASP.NET Core Blazor
// https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/call-dotnet-from-javascript?view=aspnetcore-8.0

export function returnArrayAsync() {
    const id = document.querySelector("#id-input").value;
    DotNet.invokeMethodAsync('JsCsharpInterop', 'GetFormattedSerial', id)
        .then(data => {
            document.querySelector("#dot-net-result").textContent = data;
        });
}

export function addHandlers() {
    const btn = document.getElementById("btn");
    btn.addEventListener("click", returnArrayAsync);
}

// The instructions in the YouTube video:
// https://www.youtube.com/watch?v=HcVfL9o4LUw
// parallels the steps in the learn.microsoft.com link above.
