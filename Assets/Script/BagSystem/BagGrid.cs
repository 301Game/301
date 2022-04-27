using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGrid
{
    // 格子索引,默认为1
    protected int mIndex = 1; 
    public int Index
    {
        get { return mIndex; }

    }
    //格子里的物品对象，默认为null
    protected BaseItem mItem = null;
    public BaseItem Item
    {
        get
        {
            return mItem;
        }
    }
    protected int mAmount = 0;
    public int Amount
    {
        get
        {
            return mAmount;
        }
    }
    //判断格子内是否为空
    public bool isEmpty
    {
        get
        {
            return mAmount == 0;
        }
    }
    public BagGrid(int index)
    {
        mIndex = index;
        Clear();
    }

    //放置物品
    public void SetItem(BaseItem item, int amount)
    {
        if (item != mItem)
            mItem = item;
        mAmount = amount;
    }

   //添加物品数量
    public int AddAmount(int amount)
    {
        mAmount += amount;
        return mAmount;
    }
    //减少物品数量
    public void SubAmount(int amount)
    {
        mAmount -= amount;
        if (mAmount <= 0)
            Clear();
    }
    //清空格子
    protected virtual void Clear()
    {
        mItem = null;
        mAmount = 0;
    }
    
    public override string ToString()
    {
        return string.Format("Index:{0}, Item [{1}], Amount:{2}", mIndex, mItem.ToString(), mAmount);
    }
}
