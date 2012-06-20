module Util


type 'a RefEquality(item:'a) = 

    member x.Item = item

    interface System.IComparable with
      member x.CompareTo y =
          match obj.ReferenceEquals(x, y) with 
          | true -> 0
          | false -> 1

