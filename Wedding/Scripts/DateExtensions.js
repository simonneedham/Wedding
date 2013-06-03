Date.prototype.addMinutes = function (minutes) {
    return new Date(this.getTime() + minutes * 60000);
}

Date.prototype.getUtcDateObject = function () {
    return new Date(this.toUTCString());
}

Date.prototype.getLocalDateObject = function () {
    return new Date(this.toLocaleString())
}