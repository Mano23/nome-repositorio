using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pregao.Util
{
    public static class Extensoes
    {
        #region Select List

        public static List<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> enumerable,
            Func<T, string> text,
            Func<T, string> value,
            string defaultOption, string defaultOptionValue)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = defaultOptionValue
            });
            return items;
        }

        public static List<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> enumerable,
            Func<T, string> text,
            Func<T, string> value,
            string defaultOption,
            string defaultOptionValue,
            string selected)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = defaultOptionValue
            });

            items.Find(x => x.Value.Equals(selected)).Selected = true;

            return items;
        }

        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> enumerable, string defaultOption, string defaultOptionValue)
        {
            var items = new SelectList(enumerable).ToList();

            items.Insert(0, new SelectListItem()
            {
                Text = defaultOption,
                Value = defaultOptionValue
            });
            return items;
        }

        public static List<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> enumerable,
            Func<T, string> text,
            Func<T, string> value,
            string selected)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();

            items.Find(x => x.Value.Equals(selected)).Selected = true;

            return items;
        }

        public static List<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> enumerable,
            Func<T, string> text,
            Func<T, string> value)
        {
            var items = enumerable.Select(f => new SelectListItem()
            {
                Text = text(f),
                Value = value(f)
            }).ToList();
            return items;
        }

        #endregion
    }
}