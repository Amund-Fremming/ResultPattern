﻿using Microsoft.AspNetCore.Mvc;

namespace ResultPattern.src
{
    public static class SimpleResultExtention
    {
        /// <summary>
        /// Resolves the result of a given <see cref="SimpleResult{T}"/> by executing the appropriate action based on its success or failure state.
        /// This method is commonly used in controllers to return different <see cref="ActionResult"/>s based on the outcome of the result.
        /// </summary>
        /// <param name="result">The result object, which indicates whether the operation was successful or not.</param>
        /// <param name="success">A function that takes the <see cref="Result"/> as input and returns a successful <see cref="ActionResult"/> when the operation is successful.</param>
        /// <param name="error">A function that takes the <see cref="Result"/> as input and returns a failure <see cref="ActionResult"/> when the operation fails.</param>
        /// <returns>An <see cref="ActionResult"/> representing either a successful or failure response based on the outcome of the result.</returns>
        public static ActionResult Resolve(this SimpleResult result, Func<SimpleResult, ActionResult> success, Func<SimpleResult, ActionResult> error)
            => result.IsError ? error(result) : success(result);

        /// <summary>
        /// Resolves the result of a given <see cref="SimpleResult{T}"/> by executing the appropriate action based on its success or failure state.
        /// This method is commonly used in controllers to return different <see cref="ActionResult"/>s based on the outcome of the result.
        /// </summary>
        /// <typeparam name="T">The type of data contained within the <see cref="SimpleResult{T}"/>.</typeparam>
        /// <param name="result">The result object, which indicates whether the operation was successful or not.</param>
        /// <param name="success">A function that takes the <see cref="SimpleResult{T}"/> as input and returns a successful <see cref="ActionResult"/> when the operation is successful.</param>
        /// <param name="error">A function that takes the <see cref="SimpleResult{T}"/> as input and returns a failure <see cref="ActionResult"/> when the operation fails.</param>
        /// <returns>An <see cref="ActionResult"/> representing either a successful or failure response based on the outcome of the result.</returns>
        public static ActionResult Resolve<T>(this SimpleResult<T> result, Func<SimpleResult<T>, ActionResult> success, Func<SimpleResult<T>, ActionResult> error)
            => result.IsError ? error(result) : success(result);

        /// <summary>
        /// Changes type T to type U.
        /// </summary>
        public static SimpleResult<U> ToType<T, U>(this SimpleResult<T> result) => new(default!, result.Error!);

        /// <summary>
        /// Adds type T to the Result.
        /// </summary>
        public static SimpleResult<T> AddType<T>(this SimpleResult result) => new(default!, result.Error!);

        /// <summary>
        /// Removes type T from Result.
        /// </summary>
        public static SimpleResult RemoveType<T>(this SimpleResult<T> result) => new(result.Error);
    }
}